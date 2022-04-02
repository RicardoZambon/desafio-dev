import { Component, OnInit } from '@angular/core';

import { TransactionsService } from 'src/app/shared/services/transactions.service';

@Component({
  selector: 'app-operations-summary',
  templateUrl: './operations-summary.component.html',
  styleUrls: ['./operations-summary.component.scss']
})
export class OperationsSummaryComponent implements OnInit {
  
  public numberFormatter = new Intl.NumberFormat('en-US', { style: 'decimal', minimumFractionDigits: 0, maximumFractionDigits: 0 });
  public valueFormatter = new Intl.NumberFormat('en-US', { style: 'decimal', minimumFractionDigits: 2, maximumFractionDigits: 2 });

  transactionSummary = this.transactionsService.summary({ filters: {} });

  constructor(private transactionsService: TransactionsService) {
  }

  ngOnInit(): void {
    
  }

  refreshSummary(filters: { [index: string]: Object }) {
    this.transactionSummary = this.transactionsService.summary({ filters: filters });
  }
}