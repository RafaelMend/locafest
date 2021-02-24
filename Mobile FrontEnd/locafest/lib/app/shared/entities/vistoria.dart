class Vistoria {
  String id;
  bool indiceCarroLimpo;
  bool indiceTanqueCheio;
  bool indiceAmassados;
  bool indiceArranhoes;
  int percentualOcorrencia;
  String contratoId;

  Vistoria(
      {this.id,
      this.indiceCarroLimpo,
      this.indiceTanqueCheio,
      this.indiceAmassados,
      this.indiceArranhoes,
      this.percentualOcorrencia,
      this.contratoId});

  Vistoria.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    indiceCarroLimpo = json['indiceCarroLimpo'];
    indiceTanqueCheio = json['indiceTanqueCheio'];
    indiceAmassados = json['indiceAmassados'];
    indiceArranhoes = json['indiceArranhoes'];
    percentualOcorrencia = json['percentualOcorrencia'];
    contratoId = json['contratoId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['indiceCarroLimpo'] = this.indiceCarroLimpo;
    data['indiceTanqueCheio'] = this.indiceTanqueCheio;
    data['indiceAmassados'] = this.indiceAmassados;
    data['indiceArranhoes'] = this.indiceArranhoes;
    data['percentualOcorrencia'] = this.percentualOcorrencia;
    data['contratoId'] = this.contratoId;
    return data;
  }
}