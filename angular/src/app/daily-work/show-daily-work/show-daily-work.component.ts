import {
  Component,
  EventEmitter,
  Injector,
  OnInit,
  Output,
} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import {
  DailyWorkServiceProxy,
  DailyWorkDto
} from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  templateUrl: './show-daily-work.component.html',
})
export class ShowDailyWorkComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  dailyWork = new DailyWorkDto();
  id: string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _dailyWorkService: DailyWorkServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._dailyWorkService.get(this.id).subscribe((result) => {
      this.dailyWork = result;
    });
  }

  close(): void {
    this.bsModalRef.hide();
    this.onSave.emit();
  }
}
