import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  DailyWorkServiceProxy,
  DailyWorkDto
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-edit-daily-work',
  templateUrl: './edit-daily-work.component.html',
  animations: [appModuleAnimation()]
})
export class EditDailyWorkComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  dailyWork = new DailyWorkDto();
  id: string;


  editorConfig = {
    height: 500,
    menubar: false,
    language: "zh_CN",
    language_url: "assets/tinymce/langs/zh_CN.js",
    plugins: [
      'advlist autolink lists link image charmap print preview anchor',
      'searchreplace visualblocks code fullscreen',
      'insertdatetime media table paste code help wordcount'
    ],
    toolbar:
      'code | undo redo | formatselect | bold italic backcolor | \
                                       alignleft aligncenter alignright alignjustify | \
                                       bullist numlist outdent indent | removeformat | help'
  };

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _dailyWorkService: DailyWorkServiceProxy,
    private router: Router,
    private route: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.route.queryParams.subscribe((params: Params) => {
      this.id = params["id"];
      this._dailyWorkService.get(this.id).subscribe((result) => {
        this.dailyWork = result;
      });
    });

  }

  save(): void {
    this.saving = true;
    this._dailyWorkService
      .update(this.dailyWork)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.router.navigate(['../'], { relativeTo: this.route });
      });
  }

  cancelEvent(): void {
    this.router.navigate(['../'], { relativeTo: this.route });
  }
}
