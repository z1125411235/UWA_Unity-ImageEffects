﻿using UnityEngine;
using System.Collections;

namespace irishoak.ImageEffects {

	[ExecuteInEditMode]
	public class PaletteQuantizationAndDithering : MonoBehaviour {

		[SerializeField]
		Shader   _shader;

		#region Params
		[SerializeField]
		Texture2D _ditheringTex;
		#endregion

		Material _m;

		void OnRenderImage (RenderTexture source, RenderTexture destination)
		{
			if (_m == null) {
				_m = new Material (_shader);
				_m.hideFlags = HideFlags.DontSave;
			}

			_m.SetVector  ("_ScreenResolution", new Vector2 (Screen.width, Screen.height));
			_m.SetTexture ("_DitheringTex", _ditheringTex);
			
			Graphics.Blit (source, destination, _m);
		}

		void OnDestroy ()
		{
			if (_m != null) {
				DestroyImmediate (_m);
			}
		}
	}
}