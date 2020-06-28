import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DataservicesProvider } from '../../providers/dataservices/dataservices';


@Injectable({
  providedIn: 'root'
  
})
export class MLDashboardService {
  constructor(private _DataservicesProvider: DataservicesProvider) { }
   Search (MLDashBoard) {
     return this._DataservicesProvider.PostData(environment.MLApiUrl, MLDashBoard);
   }
   //GetMLDetails (lobDetailsRequest) {
   //  return this._DataservicesProvider.PostData(environment.MLApiUrl + '/GetMovieLocations', lobDetailsRequest);
   //}
}
