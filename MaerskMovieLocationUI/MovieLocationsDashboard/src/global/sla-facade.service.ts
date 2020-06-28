import { Injectable, Injector } from '@angular/core';
import { MLDashboardService } from '../app/mldash-board/mldash-board.service';


@Injectable({
  providedIn: 'root'

})
export class MLAFacadeService {
  //#region "Injected Service Object"
  private _mlaDashboardService: MLDashboardService;
 
  //#endregion

  //#region "Injected Service Object Initialisation"
  public get mlaDashboardService(): MLDashboardService {
    if (!this._mlaDashboardService) {
      this._mlaDashboardService = this.injector.get(MLDashboardService);
    }
    return this._mlaDashboardService;
  }

  //#endregion
  constructor(private injector: Injector) {

  }
  //#region "Apj Ats Search Methods"

  Search(MLADashBoard) {
    return this.mlaDashboardService.Search(MLADashBoard);
  }
  
  //#endregion
}
