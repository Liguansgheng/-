package lgs.GameSnake;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Point;

import lgs.GameUtil.Config;

public abstract class SnakeObject {
	//����
	int x,y;
	
	//��ӦͼƬ
	Image img;
	
	//ͼƬ��С
	int ImgWidth = Config.ImageWidth;
	int ImgHeight = Config.ImageHeight;
	
	//��ǰ״̬
	public boolean IsLive;
	
	//�滭����
	public abstract void Draw(Graphics g);
	
	/*�ж�ʵ����ײ��������Ϊ��������ͬ�ĵ㣬��������ཻ����
	 * ���ڸ���Ϸ��ͼ�ι涨Ϊ�����Σ�����speed��ͼƬ��С��ͬ�������
	 * �ܶ�򻯣���Ϸ��ֻ����������ײ�����ֻ��Ҫ����ͼ�����ĵ�ľ��룬
	 * �ٳ���ͼƬ�ĳ��ȣ��Ϳ��Եõ�����ͼ�ε��ص�������0-1����ͨ��������ֵ���õ�
	 * ����ʵ���Ƿ���ײ�Ľ��
	 */
	public boolean  IsIntersectedByDegree(Point PointA,Point PointB,float Degree) {
		//�ص�����
		float ThisDegree = 1 - (float)PointA.distance(PointB)/Config.ImageWidth;
		if(ThisDegree >=  Degree)
			return true;
		else
			return false;
	}
}
