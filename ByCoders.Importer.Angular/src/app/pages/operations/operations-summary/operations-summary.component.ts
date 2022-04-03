import { Component, OnInit } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { DefaultFormatters } from 'src/app/shared/grid-formatters';
import { TransactionsSummary } from 'src/app/shared/models/transactions-summary';

import { TransactionsService } from 'src/app/shared/services/transactions.service';

@Component({
  selector: 'app-operations-summary',
  templateUrl: './operations-summary.component.html',
  styleUrls: ['./operations-summary.component.scss']
})
export class OperationsSummaryComponent implements OnInit {
  
  valueKind: 'deposit' | 'withdraw' = 'deposit';

  transactionSummary!: Observable<{ totalItems: string, totalValue: string }>;

  constructor(private transactionsService: TransactionsService) {
    this.refreshSummary({ filters: {} });
  }

  ngOnInit(): void {
    
  }

  refreshSummary(filters: { [index: string]: Object }) {
    this.transactionSummary = this.transactionsService
    .summary({ filters: filters })
    .pipe(
        tap((summary: TransactionsSummary) => {
          this.valueKind = summary.totalValue > 0 ? 'deposit' : 'withdraw';
        }),
        map((summary: TransactionsSummary) => {
            return {
                totalItems: DefaultFormatters.numberFormatter.format(summary.totalItems),
                totalValue: DefaultFormatters.valueFormatter.format(summary.totalValue)
            };
        })
    );
  }
}