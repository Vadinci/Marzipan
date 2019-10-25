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
		public KeyboardInput keyboard { get; private set; }
		public TouchInput touch { get; private set; }

		private List<IInput> _inputs;

		public Input() {
			_inputs = new List<IInput>();

			keyboard = new KeyboardInput();
			_inputs.Add(keyboard);

			touch = new TouchInput();
			if (TouchPanel.GetCapabilities().IsConnected) {
				_inputs.Add(touch);
			}
		}

		public void Update() {
			foreach (IInput input in _inputs) {
				input.Update();
			}
		}
	}


	public class KeyboardInput : IInput
	{
		private KeyboardState _prevState;
		private KeyboardState _currentState;

		public KeyboardInput() {
			_currentState = Keyboard.GetState();
			_prevState = _currentState;
		}

		public void Update() {
			_prevState = _currentState;
			_currentState = Keyboard.GetState();
		}

		public bool Pressed(Keys key) {
			return _prevState.IsKeyUp(key) && _currentState.IsKeyDown(key);
		}

		public bool Check(Keys key) {
			return _currentState.IsKeyDown(key);
		}

		public bool Released(Keys key) {
			return _prevState.IsKeyDown(key) && _currentState.IsKeyUp(key);
		}
	}

	//TODO mouse

	//TODO touch (needs much more)
	public class TouchInput : IInput
	{
		private TouchCollection _currentState;
		private List<int> _idList = new List<int>();

		public void Update() {
			_idList.Clear();

			if (TouchPanel.GetCapabilities().IsConnected) {
				_currentState = TouchPanel.GetState();
			} else {
				_currentState = new TouchCollection();
			}
		}

		public List<int> GetTouchIds() {
			if (_currentState.Count != _idList.Count) {
				foreach (TouchLocation t in _currentState) {
					_idList.Add(t.Id);
				}
			}
			return _idList;
		}

		public TouchLocation GetTouch(int id) {
			foreach (TouchLocation t in _currentState) {
				if (t.Id == id) return t;
			}
			//TouchLocation is not nullable, so we return an invalid one
			return new TouchLocation(id, TouchLocationState.Invalid, Vector2.Zero);
		}
	}
}
