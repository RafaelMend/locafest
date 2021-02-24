class Veiculo {
  String id;
  String placa;
  int ano;
  int valorHora;
  int limitePortaMala;
  String categoriaId;
  String combustivelId;
  String marcaId;
  String modeloId;

  Veiculo(
      {this.id,
      this.placa,
      this.ano,
      this.valorHora,
      this.limitePortaMala,
      this.categoriaId,
      this.combustivelId,
      this.marcaId,
      this.modeloId});

  Veiculo.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    placa = json['placa'];
    ano = json['ano'];
    valorHora = json['valorHora'];
    limitePortaMala = json['limitePortaMala'];
    categoriaId = json['categoriaId'];
    combustivelId = json['combustivelId'];
    marcaId = json['marcaId'];
    modeloId = json['modeloId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['placa'] = this.placa;
    data['ano'] = this.ano;
    data['valorHora'] = this.valorHora;
    data['limitePortaMala'] = this.limitePortaMala;
    data['categoriaId'] = this.categoriaId;
    data['combustivelId'] = this.combustivelId;
    data['marcaId'] = this.marcaId;
    data['modeloId'] = this.modeloId;
    return data;
  }
}