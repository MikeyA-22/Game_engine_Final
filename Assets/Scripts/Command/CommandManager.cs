using System.Collections.Generic;
using UnityEngine;
    public class CommandManager:MonoBehaviour
    {
        public static CommandManager Instance { get; private set; }
  
        private Stack<ICommand> m_CommandsBuffer = new Stack<ICommand>();
  
        private void Awake()
        {
            Instance = this;
        }
  
        public void AddCommand(ICommand command)
        {
            command.Execute();
            
            m_CommandsBuffer.Push(command);
        }

        public void RemoveCommand(ICommand command)
        {
            if (m_CommandsBuffer.Count == 0)
                return;
        
            m_CommandsBuffer.Pop();
            command.Undo();
        
        }        
        
    }
