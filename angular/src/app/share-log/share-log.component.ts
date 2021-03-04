import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  DailyWorkServiceProxy,
  DailyWorkDto,
  DailyWorkDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { Router, ActivatedRoute, BaseRouteReuseStrategy } from '@angular/router';
import { ShowDailyWorkComponent } from '../daily-work/show-daily-work/show-daily-work.component';
import { BsModalService } from 'ngx-bootstrap/modal';

class PagedDailyWorksRequestDto extends PagedRequestDto {
  keyword: string;
  isPublished: boolean | null;
  userName: string;
  userId: number;
}

@Component({
  selector: 'app-share-log',
  templateUrl: './share-log.component.html'
})
export class ShareLogComponent
  extends PagedListingComponentBase<DailyWorkDto> implements OnInit {
  dailyWorks: DailyWorkDto[] = [];
  keyword = '';
  userName = '';

  constructor(
    injector: Injector,
    private _dailyWorkService: DailyWorkServiceProxy,
    private router: Router,
    private route: ActivatedRoute,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  clearFilters(): void {
    this.keyword = '';
    this.userName = '';
    this.getDataPage(1);
  }

  protected list(
    request: PagedDailyWorksRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isPublished = true;
    request.userName = this.userName;
    request.userId = -1;

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

  delete(): void { }

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

}
