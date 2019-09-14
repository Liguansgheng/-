package lgs.GameUtil;

public class ImageRandom {
	//·µ»ØËæ»úÍ¼Æ¬Ãû×Ö
	public static String GetRandomImgName() {
		String[] ImgName = ImageLoad.GetImgName();
		int RandomIndex = (int) (Math.random()*ImgName.length);
		return ImgName[RandomIndex];
	}
}
