class Simulacao {
  String veiculoId;
  String dataRetirada;
  String dataDevolucao;
  int valorHora;
  int quantidadeHoras;
  int valorTotal;

  Simulacao(
      {this.veiculoId,
      this.dataRetirada,
      this.dataDevolucao,
      this.valorHora,
      this.quantidadeHoras,
      this.valorTotal});

  Simulacao.fromJson(Map<String, dynamic> json) {
    veiculoId = json['veiculoId'];
    dataRetirada = json['dataRetirada'];
    dataDevolucao = json['dataDevolucao'];
    valorHora = json['valorHora'];
    quantidadeHoras = json['quantidadeHoras'];
    valorTotal = json['valorTotal'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['veiculoId'] = this.veiculoId;
    data['dataRetirada'] = this.dataRetirada;
    data['dataDevolucao'] = this.dataDevolucao;
    data['valorHora'] = this.valorHora;
    data['quantidadeHoras'] = this.quantidadeHoras;
    data['valorTotal'] = this.valorTotal;
    return data;
  }
}