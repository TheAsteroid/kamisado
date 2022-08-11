using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kamisado.GameStates;
using Kamisado.GameStates.PlayingStates;

namespace Kamisado
{
    public class GameController
    {
        private static GameController instance;

        private StateMachine stateMachine;

        private GameController()
        {
        }

        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        public StateMachine StateMachine
        {
            get { return stateMachine; }
        }

        public void Initialize()
        {
            stateMachine = new StateMachine();
        }
    }
}
