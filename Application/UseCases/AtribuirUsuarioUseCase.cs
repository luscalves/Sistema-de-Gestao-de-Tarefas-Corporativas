using System;
using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class AtribuirUsuarioUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public AtribuirUsuarioUseCase(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
    {
        _tarefaRepository = tarefaRepository;
        _usuarioRepository = usuarioRepository;
    }

    public void Executar(int tarefaId, int usuarioId)
    {
        var tarefa = _tarefaRepository.ObterPorId(tarefaId);
        if (tarefa == null)
        {
            throw new Exception($"Tarefa com ID {tarefaId} não encontrada.");
        }

        var usuario = _usuarioRepository.ObterPorId(usuarioId);
        if (usuario == null)
        {
            throw new Exception($"Operação negada: Usuário com ID {usuarioId} não existe no sistema.");
        }
        
        tarefa.AtribuirUsuario(usuario);
        
        _tarefaRepository.Atualizar(tarefa);
    }
}
