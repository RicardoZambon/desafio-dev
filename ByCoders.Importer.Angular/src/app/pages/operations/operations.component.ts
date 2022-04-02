import { OperationsSummaryComponent } from './operations-summary/operations-summary.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef } from 'ag-grid-community';

import { TransactionsService } from './../../shared/services/transactions.service';
import { GridLoadingRendererComponent } from 'src/app/shared/components/grid/grid-loading-renderer-component/grid-loading-renderer.component';
import { cpfFormatter, currencyFormatter, dateTimeFormatter } from 'src/app/shared/grid-formatters';
import { OperationsDatasource } from './../../shared/datasources/operations-datasource';

@Component({
  selector: 'app-operations',
  templateUrl: './operations.component.html',
  styleUrls: ['./operations.component.scss'],
  host: { class: 'w-100 d-flex flex-column' },
})
export class OperationsComponent implements OnInit {

  @ViewChild('grid') grid!: AgGridAngular;
  @ViewChild('summary') summary!: OperationsSummaryComponent;

  frameworkComponents: any = {
    loadingRenderer: GridLoadingRendererComponent
  };
  
  cellRendererParams = { loadingMessage: 'Loading...', loadingMessageFailure: '' };

  columnDefs: ColDef[] = [
    { colId: 'date',            field: 'date',            headerName: 'Date', suppressMovable: true, minWidth: 170, maxWidth: 170, sortable: true, cellRenderer: 'loadingRenderer', cellRendererParams: this.cellRendererParams, valueFormatter: dateTimeFormatter },
    { colId: 'shopName',        field: 'shopName',        headerName: 'Shop Name', suppressMovable: true, minWidth: 150, sortable: true, flex: 1 },
    { colId: 'shopOwner',       field: 'shopOwner',       headerName: 'Shop Owner', suppressMovable: true, minWidth: 150, sortable: true, flex: 1 },
    { colId: 'cpf',             field: 'cpf',             headerName: 'CPF', suppressMovable: true, minWidth: 150, maxWidth: 150, sortable: false, flex: 1, valueFormatter: cpfFormatter },
    { colId: 'transactionType', field: 'transactionType', headerName: 'Transaction Type', suppressMovable: true, minWidth: 220, maxWidth: 220, sortable: true, flex: 1 },
    { colId: 'value',           field: 'value',           headerName: 'Value', suppressMovable: true, minWidth: 110, maxWidth: 110, sortable: false, flex: 1, cellClass: 'number-cell', valueFormatter: currencyFormatter },
  ];

  dataSource = new OperationsDatasource(this.transactionsService);


  constructor(private transactionsService: TransactionsService) { }

  ngOnInit(): void {
    
  }

  onGridReady(): void {
    this.grid.api.setDatasource(this.dataSource);
  }

  setFilters(filters: { [index: string]: Object }) {
    this.dataSource.setFilters(filters);
    this.grid.api.setDatasource(this.dataSource);
    this.summary.refreshSummary(filters);
  }
}