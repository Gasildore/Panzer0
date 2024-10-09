using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Panzer0.Base.ConsoleInput;

namespace Panzer0.Base
{
    internal abstract class BaseGameLogic : IArrowListener
    {
        protected BaseGameState? currentState { get; private set; }
        protected float time { get; private set; }
        protected int screenWidth { get; private set; }
        protected int screenHeight { get; private set; }

        public abstract ConsoleColor[] CreatePalette();
        public abstract void Update(float deltaTime);
        public abstract void OnArrowDown();
        public abstract void OnArrowLeft();
        public abstract void OnArrowRight();
        public abstract void OnArrowUp();
        public abstract void OnShoot();

        public void InitializeInput(ConsoleInput input)
        {
            input.Subscribe(this);
        }

        public void ChangeState(BaseGameState state)
        {
            currentState?.Reset();
            currentState = state;
        }

        public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
        {
            time += deltaTime;

            screenWidth = renderer._width;
            screenHeight = renderer._height;

            currentState?.Update(deltaTime);
            currentState?.Draw(renderer);

            Update(deltaTime);
        }
    }
}
