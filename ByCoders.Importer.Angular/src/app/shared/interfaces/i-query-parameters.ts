export interface IQueryParameters {
    startRow: number;

    endRow: number;

    sort: { [index: string]: string };

    filters: { [index: string]: string };
}