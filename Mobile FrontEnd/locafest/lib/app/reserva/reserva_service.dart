import 'package:locafest/app/shared/entities/agendamento.dart';
import 'package:uuid/uuid.dart';

class ReservaService {
  var uuid = Uuid();

  static Future<List<Agendamento>> obterMinhasReservas(String idCliente) async {
    var uuid = Uuid();
    Agendamento a1 = new Agendamento(
      id: uuid.v1(),
      clienteId: uuid.v1(),
      dataRetirada: DateTime.now().toString(),
      dataDevolucao: DateTime.now().toString(),
      local: "Belo Horizonte",
      quantidadeHoras: 36,
      valorHora: 10,
      valorFinal: 360,
      veiculoId: uuid.v1()
    );

    Agendamento a2 = new Agendamento(
        id: uuid.v1(),
        clienteId: uuid.v1(),
        dataRetirada: DateTime.now().toString(),
        dataDevolucao: DateTime.now().toString(),
        local: "Belo Horizonte",
        quantidadeHoras: 36,
        valorHora: 10,
        valorFinal: 360,
        veiculoId: uuid.v1()
    );
    Agendamento a3 = new Agendamento(
        id: uuid.v1(),
        clienteId: uuid.v1(),
        dataRetirada: DateTime.now().toString(),
        dataDevolucao: DateTime.now().toString(),
        local: "Belo Horizonte",
        quantidadeHoras: 36,
        valorHora: 10,
        valorFinal: 360,
        veiculoId: uuid.v1()
    );

    List<Agendamento> lista = [];
    lista.add(a1);
    lista.add(a2);
    lista.add(a3);

    return lista;
  }
}