class Agendamento {
  String id;
  String dataRetirada;
  String dataDevolucao;
  String local;
  int valorHora;
  int quantidadeHoras;
  int valorFinal;
  String veiculoId;
  String clienteId;

  Agendamento(
      {this.id,
      this.dataRetirada,
      this.dataDevolucao,
      this.local,
      this.valorHora,
      this.quantidadeHoras,
      this.valorFinal,
      this.veiculoId,
      this.clienteId});

  Agendamento.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    dataRetirada = json['dataRetirada'];
    dataDevolucao = json['dataDevolucao'];
    local = json['local'];
    valorHora = json['valorHora'];
    quantidadeHoras = json['quantidadeHoras'];
    valorFinal = json['valorFinal'];
    veiculoId = json['veiculoId'];
    clienteId = json['clienteId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['dataRetirada'] = this.dataRetirada;
    data['dataDevolucao'] = this.dataDevolucao;
    data['local'] = this.local;
    data['valorHora'] = this.valorHora;
    data['quantidadeHoras'] = this.quantidadeHoras;
    data['valorFinal'] = this.valorFinal;
    data['veiculoId'] = this.veiculoId;
    data['clienteId'] = this.clienteId;
    return data;
  }
}