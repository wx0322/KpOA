import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  DailyWorkServiceProxy,
  DailyWorkDto,
  DailyWorkDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ShowDailyWorkComponent } from './show-daily-work/show-daily-work.component';

class PagedDailyWorksRequestDto extends PagedRequestDto {
  keyword: string;
  isPublished: boolean | null;
  userName: string;
  userId: number;
}

@Component({
  selector: 'app-daily-work',
  templateUrl: './daily-work.component.html',
  animations: [appModuleAnimation()]
})
export class DailyWorkComponent
  extends PagedListingComponentBase<DailyWorkDto> implements OnInit {
  dailyWorks: DailyWorkDto[] = [];
  keyword = '';
  userId = -1;
  isPublished: boolean | null;

  constructor(
    injector: Injector,
    private _dailyWorkService: DailyWorkServiceProxy,
    private router: Router,
    private route: ActivatedRoute,
    private _modalService: BsModalService
  ) {
    super(injector);
    this.userId = this.appSession.getUserId();
  }

  edit(dailyWork: DailyWorkDto): void {
    this.router.navigate(['edit'], { relativeTo: this.route, queryParams: { id: dailyWork.id } });
  }

  show(dailyWork: DailyWorkDto): void {
    this.showDialog(dailyWork.id);
  }

  private showDialog(id?: string): void {
    const detailDialog = this._modalService.show(
      ShowDailyWorkComponent,
      {
        class: 'modal-lg',
        initialState: {
          id: id,
        },
      }
    );

    detailDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isPublished = null;
    this.getDataPage(1);
  }

  protected list(
    request: PagedDailyWorksRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isPublished = this.isPublished;
    request.userId = this.appSession.getUserId();

    this.appSession.getUserId()
    this._dailyWorkService
      .getAll(
        request.keyword,
        request.isPublished,
        request.userName,
        request.userId,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: DailyWorkDtoPagedResultDto) => {
        this.dailyWorks = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(dailyWork: DailyWorkDto): void {
    abp.message.confirm(
      this.l('DailyWorkDeleteWarningMessage', dailyWork.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._dailyWorkService.delete(dailyWork.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
}
