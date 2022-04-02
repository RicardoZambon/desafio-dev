import { Component } from '@angular/core';
import { AgRendererComponent } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';

@Component({
  selector: 'app-grid-loading-renderer',
  templateUrl: './grid-loading-renderer.component.html'
})
export class GridLoadingRendererComponent implements AgRendererComponent {

  error = false;
  loading = true;
  params!: any;

  constructor() { }


  refresh(params: ICellRendererParams): boolean {
    this.update(params);
    return true;
  }

  agInit(params: ICellRendererParams): void {
    this.update(params);

    params.api.addEventListener('failCallback', () => {
      if (this.loading) {
          this.loading = false;
          this.error = true;
      }
    });
  }

  value(): any {
      if (this.params.formatValue) {
          return this.params.formatValue(this.params.value)
      }
      return this.params.value;
  }

  update(params: ICellRendererParams): void {
    this.loading = params.value === undefined;
    if (this.loading) {
      this.error = false;
    }

    params.node.selectable = !this.loading;
    this.params = params;
  }
}
