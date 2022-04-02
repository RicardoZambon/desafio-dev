import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { CatalogItem } from 'src/app/shared/models/catalog-item';

import { CatalogsService } from './../../../shared/services/catalogs.service';

@Component({
  selector: 'app-operations-filters',
  templateUrl: './operations-filters.component.html',
  styleUrls: ['./operations-filters.component.scss']
})
export class OperationsFiltersComponent implements OnInit {

  filterForm!: FormGroup;

  transactionType!: string;
  transactionTypes$ = this.catalogsService.transactionTypes();

  @Output() filter = new EventEmitter<{ [index: string]: Object }>();


  constructor(private formBuilder: FormBuilder, private catalogsService: CatalogsService) { }

  ngOnInit(): void {
    this.filterForm = this.formBuilder.group({
      transactionType: [],
      startDate: [],
      endDate: []
    });
  }

  async selectedTransactionType(): Promise<void> {
    if (!(await this.findTransactionType())) {
      this.filterForm.controls['transactionType'].setValue(null);
    }
  }

  clearForm(): void {
    this.filterForm.reset();
  }

  async submit(): Promise<void> {
    var filters: { [index: string]: Object } = {};

    var selectedType = await this.findTransactionType();
    if (selectedType) {
      filters['transactionType'] = selectedType.id;
    }

    if (this.filterForm.value.startDate) {
      filters['startDate'] = this.filterForm.value.startDate
    }

    if (this.filterForm.value.endDate) {
      filters['endDate'] = this.filterForm.value.endDate
    }

    this.filter.emit(filters);
  }

  private async findTransactionType(): Promise<CatalogItem> {
    var description = this.filterForm.value.transactionType;
    return (await lastValueFrom(this.transactionTypes$)).filter(x => x.description === description)[0];
  }
}