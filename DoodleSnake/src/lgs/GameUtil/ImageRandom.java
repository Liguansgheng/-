package lgs.GameUtil;

public class ImageRandom {
	//�������ͼƬ����
	public static String GetRandomImgName() {
		String[] ImgName = ImageLoad.GetImgName();
		int RandomIndex = (int) (Math.random()*ImgName.length);
		return ImgName[RandomIndex];
	}
}
