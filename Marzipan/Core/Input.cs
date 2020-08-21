using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

//TODO what if each scene manages their own input? It might be a bit messy, but this way it's easy to have all input blocked on one scene but not another, useful for menus etc.

//TODO look into Monocle's virtual input system. I imagine it's something like creating an 'Attack' Button, that than internally checks with actual cotnroller/keyboard/mouse shit, and you just poll that button

namespace Marzipan.Core
{
	public interface IInput
	{
		void Update();
	}

	public class Input
	{
		public static KeyboardInput Keyboard { get; private set; }

		private static List<IInput> inputs;

		public static void Initialize() {
			inputs = new List<IInput>();

			Keyboard = new KeyboardInput();
			inputs.Add(Keyboard);
		}

		public static void Update() {
			foreach (IInput input in inputs) {
				input.Update();
			}
		}
	}


	public class KeyboardInput : IInput
	{
		private KeyboardState prevState;
		private KeyboardState currentState;

		public KeyboardInput() {
			currentState = Keyboard.GetState();
			prevState = currentState;
		}

		public void Update() {
			prevState = currentState;
			currentState = Keyboard.GetState();
		}

		public bool Pressed(Keys key) {
			return prevState.IsKeyUp(key) && currentState.IsKeyDown(key);
		}

		public bool Check(Keys key) {
			return currentState.IsKeyDown(key);
		}

		public bool Released(Keys key) {
			return prevState.IsKeyDown(key) && currentState.IsKeyUp(key);
		}
	}

	//TODO mouse
	//TODO controllers
}
