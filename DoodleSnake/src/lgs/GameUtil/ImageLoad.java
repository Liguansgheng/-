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
 * ��������⣨ѧϰJava���ڣ�����ģ���
 *   ��GetImgName()�Ѿ���file����ʽ����������ͼƬ�ļ�����ʱӦ�ÿ���
 *   ֱ�Ӵ���Map���棬�����������ں�����ļ���ʽһֱ��imge��ʽ��
 *   ��GetImgName()�����ǰٶȵõ��ģ��ܿ����������Լ�������ȥ�ľ���ȫ���ᣬ
 *   ��ˣ����ﶵ��һ��Ȧ�ӡ�
 */
public class ImageLoad {
	//��ͼƬ���ڴ�����������ÿ�λ滭ʱ�Ͳ���Ҫ��Ӳ���ж�ȡ
	public static Map<String,Image> images = new HashMap<>();
	
	//����ͼƬ
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
	
	//��ȡ����img�ļ����������ļ����õ�����ͼƬ����
	public static String[] GetImgName() {
		//ʹ�õ��Ǿ���·���������⣬�����ٸ�
		File file = new File("F:\\Javaprojects\\DoodleSnake\\bin\\img");// ͼƬ���·��
		File[] list = file.listFiles();
		/**
		 * ��ȡ�ļ��������е��ļ� ����ͼƬ���ļ�Ҳ�ᱻ��ȡ�ģ� �������ר���������ͼƬ���ļ������ַ������� ����Ļ���Ҫ�ж��ļ���������
		 */
		String[] ImgName = new String[list.length];
		for(int i= 0;i<list.length;i++) 
			ImgName[i] = list[i].getName().substring(0,list[i].getName().length()-4);   //ȥ��.jpg
		return ImgName;
	}
	
	//�������ֽ����ֺ�ͼƬ�Լ�ֵ�Ե���ʽ����map��
	static {
		for(String IN:GetImgName())
			images.put(IN, getImage("img/"+ IN +".jpg"));
	}
}
