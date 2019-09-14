package lgs.GameUtil;

import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;
import javax.imageio.ImageIO;
import java.io.File;
import java.util.HashMap;
import java.util.Map;
/*
 * 设计有问题（学习Java初期，不会改）：
 *   在GetImgName()已经以file的形式加载了所有图片文件，此时应该可以
 *   直接传入Map里面，但是这里由于后面的文件形式一直是imge形式，
 *   且GetImgName()函数是百度得到的，能看懂，但以自己的需求去改就完全不会，
 *   因此，这里兜了一个圈子。
 */
public class ImageLoad {
	//出图片到内存中来，这样每次绘画时就不需要从硬盘中读取
	public static Map<String,Image> images = new HashMap<>();
	
	//加载图片
	public static Image getImage(String path) {
		URL url = ImageLoad.class.getClassLoader().getResource(path);
		BufferedImage image = null;
		try {
			image = ImageIO.read(url);
		} catch (IOException e) {
			e.printStackTrace();
		}
		return image;
	}
	
	//读取所有img文件夹下所有文件，得到所有图片名字
	public static String[] GetImgName() {
		//使用的是绝对路径，有问题，后面再改
		File file = new File("F:\\Javaprojects\\DoodleSnake\\bin\\img");// 图片存放路径
		File[] list = file.listFiles();
		/**
		 * 获取文件夹下所有的文件 不是图片的文件也会被读取的， 如果你是专门用来存放图片的文件，这种方法可行 否则的话就要判断文件的类型了
		 */
		String[] ImgName = new String[list.length];
		for(int i= 0;i<list.length;i++) 
			ImgName[i] = list[i].getName().substring(0,list[i].getName().length()-4);   //去掉.jpg
		return ImgName;
	}
	
	//根据名字将名字和图片以键值对的形式存入map中
	static {
		for(String IN:GetImgName())
			images.put(IN, getImage("img/"+ IN +".jpg"));
	}
}
