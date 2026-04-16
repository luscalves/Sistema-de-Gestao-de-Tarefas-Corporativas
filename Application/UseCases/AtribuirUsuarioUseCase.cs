using System;
using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class AtribuirUsuarioUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    // Injetamos os DOIS repositórios!
    public AtribuirUsuarioUseCase(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
    {
        _tarefaRepository = tarefaRepository;
        _usuarioRepository = usuarioRepository;
    }

    public void Executar(int tarefaId, int usuarioId)
    {
        // 1. Busca a tarefa
        var tarefa = _tarefaRepository.ObterPorId(tarefaId);
        if (tarefa == null)
        {
            throw new Exception($"Tarefa com ID {tarefaId} não encontrada.");
        }

        // 2. Busca o usuário (A validação de segurança!)
        var usuario = _usuarioRepository.ObterPorId(usuarioId);
        if (usuario == null)
        {
            throw new Exception($"Operação negada: Usuário com ID {usuarioId} não existe no sistema.");
        }

        // 3. Usa a regra de negócio que você já criou na Entidade!
        // Lembra que esse método lá no Tarefa.cs já muda o status para 'EmAndamento'?
        tarefa.AtribuirUsuario(usuario);

        // 4. Salva a alteração no banco
        _tarefaRepository.Atualizar(tarefa);
    }
}