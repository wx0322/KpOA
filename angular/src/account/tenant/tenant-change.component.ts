import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { TenantChangeDialogComponent } from './tenant-change-dialog.component';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AccountServiceProxy, IsTenantAvailableInput, IsTenantAvailableOutput } from '../../shared/service-proxies/service-proxies';

@Component({
  selector: 'tenant-change',
  templateUrl: './tenant-change.component.html'
})
export class TenantChangeComponent extends AppComponentBase implements OnInit {
  tenancyName = '';
  name = '';

  constructor(injector: Injector,
    private _accountService: AccountServiceProxy,
    private _modalService: BsModalService) {
    super(injector);
  }

  get isMultiTenancyEnabled(): boolean {
    return abp.multiTenancy.isEnabled;
  }

  ngOnInit() {
    if (this.appSession.tenant) {
      this.tenancyName = this.appSession.tenant.tenancyName;
      this.name = this.appSession.tenant.name;
    } else {
      const input = new IsTenantAvailableInput();
      input.tenancyName = 'Default';

      this._accountService
        .isTenantAvailable(input)
        .subscribe((result: IsTenantAvailableOutput) => {
          abp.multiTenancy.setTenantIdCookie(result.tenantId);
          location.reload();
        });
    }
  }

  showChangeModal(): void {
    const modal = this._modalService.show(TenantChangeDialogComponent);
    if (this.appSession.tenant) {
      modal.content.tenancyName = this.appSession.tenant.tenancyName;
    }
  }
}
