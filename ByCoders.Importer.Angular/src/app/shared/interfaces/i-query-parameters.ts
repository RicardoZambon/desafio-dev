import { ISummaryParameters } from './i-summary-parameters';
export interface IQueryParameters extends ISummaryParameters {
    startRow: number;

    endRow: number;

    sort: { [index: string]: string };
}