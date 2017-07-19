using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTexts : MonoBehaviour {

	public Transform canvas_transform;

	// Use this for initialization
	void Start () {
		//CreateImage (canvas_transform, 0f, 0f, "https://www.chateagratis.net/images/notaamor.png", 100, 30);

		CreateImage (canvas_transform, -100f, 50f, "https://s-media-cache-ak0.pinimg.com/originals/05/44/6a/05446a8da9ba2fbc70b7afd6467f9f14.jpg", 50, 50);
		CreateText (canvas_transform, 140f, 0f, "Some song - Some artist", 18, Color.black);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	GameObject CreateImage(Transform canvas_transform, float x, float y, string url, float h, float w)
	{
		GameObject UIImageGO = new GameObject("Image2");
		UIImageGO.transform.SetParent(canvas_transform);

		RectTransform trans = UIImageGO.AddComponent<RectTransform>();
		trans.anchoredPosition = new Vector2(x, y);
		trans.sizeDelta = new Vector2(w, h);

		Image image = UIImageGO.AddComponent<Image>();
		StartCoroutine (setImage (image, url));

		return UIImageGO;
	}

	GameObject CreateText(Transform canvas_transform, float x, float y, string text_to_print, int font_size, Color text_color)
	{
		GameObject UItextGO = new GameObject("Text2");
		UItextGO.transform.SetParent(canvas_transform);

		RectTransform trans = UItextGO.AddComponent<RectTransform>();
		trans.anchoredPosition = new Vector2(x, y);
		trans.sizeDelta = new Vector2( 400, 100);

		Text text = UItextGO.AddComponent<Text>();
		text.text = text_to_print;
		text.fontSize = font_size;
		text.color = text_color;
		text.font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;

		return UItextGO;
	}

	IEnumerator setImage(Image img, string url)
	{
		WWW www = new WWW(url);
		yield return www;
		Debug.Log (www.texture.width);
		Debug.Log (www.texture.height);
		img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
	}
		
}
