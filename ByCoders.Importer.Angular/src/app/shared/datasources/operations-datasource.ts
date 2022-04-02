import { IQueryParameters } from './../interfaces/i-query-parameters';
import { lastValueFrom } from 'rxjs';
import { InfiniteRowModelModule } from '@ag-grid-community/infinite-row-model';
import { IDatasource, IGetRowsParams } from 'ag-grid-community';

import { TransactionsService } from './../services/transactions.service';

export class OperationsDatasource implements IDatasource {
    modules = [ InfiniteRowModelModule ];

    currentFilters: { [index: string]: Object } = {};

    constructor(private transactionsService: TransactionsService) {
    }

    rowCount?: number;
    
    async getRows(params: IGetRowsParams): Promise<void> {
      const apiParams: IQueryParameters = {
        startRow: params.startRow,
        endRow: params.endRow,
        sort: params.sortModel.reduce((result, el) =>
          ({ ...result, [el.colId]: el.sort }), {}
        ),
        filters: this.currentFilters
      };

      await lastValueFrom(
        this.transactionsService.list(apiParams)
      )
      .then (data => {
        var lastRow = -1;
        if (data.length < params.endRow) {
          lastRow = data.length;
        }
        params.successCallback(data, lastRow);
      })
      .catch(() => {
        params.failCallback();
      });
    }

    setFilters(filters: { [index: string]: Object }) {
        this.currentFilters = filters;
    }
}