import { ValueFormatterParams } from 'ag-grid-community';

export function currencyFormatter(params: ValueFormatterParams) {
  const valueFormatter = new Intl.NumberFormat('en-US', { style: 'decimal', minimumFractionDigits: 2, maximumFractionDigits: 2 });
  
  const number = parseFloat(params.value);
  
  if (!isNaN(number)) {
    return valueFormatter.format(number);
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
    const date = new Date(params.value);

    const year = date.getUTCFullYear();
    const month = ('0' + (date.getUTCMonth()+1)).slice(-2);
    const day = ('0' + date.getUTCDate()).slice(-2);

    const hour = ('0' + date.getUTCHours()).slice(-2);
    const minute = ('0' + date.getUTCMinutes()).slice(-2);
    const second = ('0' + date.getUTCSeconds()).slice(-2);

    return `${day}/${month}/${year} ${hour}:${minute}:${second}`
  }
  return '';
}