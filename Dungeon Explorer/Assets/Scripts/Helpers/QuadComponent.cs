using UnityEngine;
using System.Collections;

public class QuadComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ApplyRelational(Sprite sprInfo)
	{
		//renderer.material.SetTextureScale(sprInfo.SpriteSheetName, sprInfo.SpriteSize);
		//renderer.material.SetTextureOffset(sprInfo.SpriteSheetName, sprInfo.SpritePosition);
		
		Texture tex = Resources.Load(sprInfo.SpriteSheetName) as Texture;
		
		float sprWidth = sprInfo.SpriteSize.x;
		float sprHeight = sprInfo.SpriteSize.y;
		float sprX = sprInfo.SpritePosition.x;
		float sprY = sprInfo.SpritePosition.y;
		
		float width = (float)sprWidth / (float)tex.width;
		float height = -(float)sprHeight / (float)tex.height;
		float offX = ((float)sprX / (float)tex.width);
		float offY = 1.0f - ((float)sprY / (float)tex.height);
		
		Vector2 size = new Vector2(width, height);
		Vector2 offset = new Vector2(offX, offY);
		
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
		renderer.material.mainTexture = tex;
	}
	
	public void ApplySprite(Sprite sprite)
	{
		Texture tex = Resources.Load(sprite.SpriteSheetName) as Texture;
		renderer.material.mainTexture = tex;
		
		Vector2[] uvs = new Vector2[renderer.GetComponent<MeshFilter>().mesh.uv.Length];
		
		Vector2 pixelMin = new Vector2( (float)sprite.SpritePosition.x / (float)tex.width, 1.0f - ((float)sprite.SpritePosition.y / (float)tex.height));
		
		Vector2 pixelDims = new Vector2( (float)sprite.SpriteSize.x / (float)tex.width, -((float)sprite.SpriteSize.y / (float)tex.height));;
		
		//main mesh
		{
			Vector2 min = pixelMin;// + sprite.SpritePosition;
			
			uvs[0] = min + new Vector2(pixelDims.x * 0.0f, pixelDims.y * 1.0f);
			uvs[1] = min + new Vector2(pixelDims.x * 1.0f, pixelDims.y * 1.0f);
			uvs[2] = min + new Vector2(pixelDims.x * 0.0f, pixelDims.y * 0.0f);
			uvs[3] = min + new Vector2(pixelDims.x * 1.0f, pixelDims.y * 0.0f);
			
			renderer.GetComponent<MeshFilter>().mesh.uv = uvs;
		}
	}
}
