import 'dart:async';

import 'package:locafest/app/reserva/reserva_service.dart';
import 'package:locafest/app/shared/entities/agendamento.dart';
import 'package:bloc_pattern/bloc_pattern.dart';

class ReservaData extends BlocBase {
  // Lista de escolas
  final List<Agendamento> agendamentos;
  final bool scrollToTheEnd;

  ReservaData(this.agendamentos, this.scrollToTheEnd);
}

class ReservaBloc {
  final _controller = StreamController<ReservaData>();

  ReservaBloc();

  get stream => _controller.stream;

  Future fetch(bool scrollToTheEnd, String idCliente) async {
    try {
      var res = await ReservaService.obterMinhasReservas(idCliente);
      _controller.sink.add(ReservaData(res, scrollToTheEnd));
    } catch (e) {
      _controller.addError(e);
    }
  }
}