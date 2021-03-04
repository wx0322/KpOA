import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {
  DailyWorkServiceProxy,
  CreateDailyWorkDto
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-create-daily-work',
  templateUrl: './create-daily-work.component.html',
  styleUrls: ['./create-daily-work.component.css'],
  animations: [appModuleAnimation()],
  providers: [DatePipe]
})
export class CreateDailyWorkComponent
  extends AppComponentBase implements OnInit {
  saving = false;
  dailyWork = new CreateDailyWorkDto();
  @Output() onSave = new EventEmitter<any>();

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

  constructor(
    injector: Injector,
    public _dailyWorkService: DailyWorkServiceProxy,
    private router: Router,
    private route: ActivatedRoute,
    private datePipe: DatePipe
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.dailyWork.title = "【" + this.datePipe.transform(Date.now(), "yyyy-MM-dd") + "】" +
      this.appSession.getUserDisplayName() + "-工作总结";
  }

  save(): void {
    this.saving = true;
    this._dailyWorkService
      .create(this.dailyWork)
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
