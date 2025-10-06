using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using Zenject;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        public Action OnSendMessageRequest;
        public Action OnSpawnRequest;

#if ENABLE_INPUT_SYSTEM

		[Inject] private StarterAssetsInputSchema schema;

		bool localPlayer;

        public void InitInput()
        {
			localPlayer = true;

			EnableInput();
        }

        private void OnEnable()
        {
			if (localPlayer && schema != null)
				EnableInput();
        }

        private void OnDisable()
        {
            if (localPlayer && schema != null)
                DisableInput();
        }

        private void EnableInput()
		{
            schema.Player.Move.performed += OnMove;
            schema.Player.Move.canceled += OnMove;
            schema.Player.Look.performed += OnLook;
            schema.Player.Look.canceled += OnLook;
            schema.Player.Jump.performed += OnJump;
            schema.Player.Sprint.performed += OnSprint;

            schema.Player.SendMessage.performed += OnSendMessage;
            schema.Player.Spawn.performed += OnSpawn;

            schema.Player.Enable();
        }

        private void DisableInput()
		{
            schema.Player.Move.performed -= OnMove;
            schema.Player.Move.canceled -= OnMove;
            schema.Player.Look.performed -= OnLook;
            schema.Player.Look.canceled -= OnLook;
            schema.Player.Jump.performed -= OnJump;
            schema.Player.Sprint.performed -= OnSprint;

            schema.Player.SendMessage.performed -= OnSendMessage;
            schema.Player.Spawn.performed -= OnSpawn;

            schema.Player.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
			MoveInput(context.ReadValue<Vector2>());
        }

        private void OnLook(InputAction.CallbackContext ctx)
        {
            if (cursorInputForLook)
            {
                Vector2 look = ctx.ReadValue<Vector2>();
                LookInput(look);
            }
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            JumpInput(ctx.ReadValueAsButton());
        }

        private void OnSprint(InputAction.CallbackContext ctx)
        {
            SprintInput(ctx.ReadValueAsButton());
        }

        private void OnSendMessage(InputAction.CallbackContext context)
        {
            OnSendMessageRequest?.Invoke();
        }

        private void OnSpawn(InputAction.CallbackContext context)
        {
            OnSpawnRequest?.Invoke();
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}