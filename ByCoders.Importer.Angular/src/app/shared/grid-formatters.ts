import { ValueFormatterParams } from 'ag-grid-community';

export class DefaultFormatters {
  public static numberFormatter = new Intl.NumberFormat('en-US', { style: 'decimal', minimumFractionDigits: 0, maximumFractionDigits: 0 });
  
  public static valueFormatter = new Intl.NumberFormat('en-US', { style: 'decimal', minimumFractionDigits: 2, maximumFractionDigits: 2 });
  
  public static dateTimeFormatter = Intl.DateTimeFormat('en-US', { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit', hour12: false } )
}

export function currencyFormatter(params: ValueFormatterParams) {
  const number = parseFloat(params.value);
  
  if (!isNaN(number)) {
    return DefaultFormatters.valueFormatter.format(number);
  }
  return '';
}

export function cpfFormatter(params: ValueFormatterParams) {
  if (params.value) {
    const cpf = params.value.replace(/[^\d]/g, "");
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
  }
  return '';
}

export function dateTimeFormatter(params: ValueFormatterParams) {
  if (params.value) {
    return DefaultFormatters.dateTimeFormatter.format(new Date(params.value));
  }
  return '';
}