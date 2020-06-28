import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatTooltip, MatDialog } from '@angular/material';
import { FormBuilder, FormGroup, FormsModule, NgForm, FormControl } from '@angular/forms';
import { MLAFacadeService } from '../../global/sla-facade.service';
import { DataservicesProvider } from '../../providers/dataservices/dataservices';
@Component({
  selector: 'app-mldash-board',
  templateUrl: './mldash-board.component.html',
  styleUrls: ['./mldash-board.component.css']
})
export class MLDashBoardComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  MLDashBoard: FormGroup;
  searchOptions: SearchOptions[];
  mlaItemDetails: any
  isMLItemsresponseAvilable: boolean = false;
  MLATableDataSource: MatTableDataSource<MLItemReponseDetails>;
  private mlItemRequest: MLFilterItemRequest = new MLFilterItemRequest();
  displayedColumns = ['Id', 'Title', 'ReleaseYear', 'Locations', 'ProductionCompany', 'Distributor', 'Director', 'Writer', 'Actor1', 'Actor2', 'Actor3'];
  ErrorMsg: any; 
  constructor(private fb: FormBuilder, private _DataservicesProvider: DataservicesProvider,
    private _mlaFacadeService: MLAFacadeService ) {
    this.MLDashBoard = fb.group({
      'ddlSearchBy': [null],
      'ddlFilter': [null],
      'txtSearchByvalue': [null],
    });
    this.searchOptions = [

      { SearchOptionId: 1, SearchOptionName: "All" },
      { SearchOptionId: 2, SearchOptionName: "Actor1" },
      { SearchOptionId: 3, SearchOptionName: "Director" },
      { SearchOptionId: 4, SearchOptionName: "Locations" },
      { SearchOptionId: 5, SearchOptionName: "Writer" },
      { SearchOptionId: 6, SearchOptionName: "ReleaseYear" },
      { SearchOptionId: 7, SearchOptionName: "ProductionCompany" }
    ];
  }

  ngOnInit() {
    this.Search(this.MLDashBoard, true);
  }
  Search(MLDashBoard: FormGroup, arg1: boolean) {
    this.mlItemRequest.SearchBy = this.MLDashBoard.get('ddlSearchBy').value;
    this.mlItemRequest.SearchByFilter = this.MLDashBoard.get('ddlFilter').value;
    this.mlItemRequest.SearchByValue = this.MLDashBoard.get('txtSearchByvalue').value;
    this.mlItemRequest.pageNumber = 1;    //default 
    this.mlItemRequest.pageSize = 100;   //default

    this._mlaFacadeService.Search(this.mlItemRequest)
      .subscribe(ItemDetails => {

        this.mlaItemDetails = ItemDetails;
        this.MLATableDataSource = new MatTableDataSource<MLItemReponseDetails>(this.mlaItemDetails);
      
      },
        error => { this.ErrorMsg = error as any;  });
 }

}

export interface SearchOptions {
  SearchOptionId: number;
  SearchOptionName: string;
}

export class MLFilterItemRequest {
  SearchBy: string;
  SearchByValue: string;
  SearchByFilter: string;
  pageNumber: number;
  pageSize: number;
}

export class MLItemReponseDetails {
  Id: Number;
  Title: string;
  ReleaseYear: Number;
  Locations: string;
  ProductionCompany: string;
  Distributor: string;
  Director: string;
  Writer: string;
  Actor1: string;
  Actor2: string;
  Actor3: string;

}
    


