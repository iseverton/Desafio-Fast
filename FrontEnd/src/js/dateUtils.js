function formatDate(dateString) {
  return new Date(dateString).toLocaleDateString("pt-BR");
}

export { formatDate };
