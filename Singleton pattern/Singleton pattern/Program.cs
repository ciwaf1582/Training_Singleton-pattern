using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_pattern
{
    public class Theme // 타 클래스에서 접근이 가능한 클래스명 ex) Thema.instance. ...
    {
        // 필드
        private static Theme instance; // Thema 클래스의 유일한 객체를 저장
        private string themeColor; 

        private Theme()
        {
            this.themeColor = "light"; // private라서 외부에서 이 생성자 메소드로 접근 제한(new 제한)
        }
        public static Theme getInstance() // getter
        {
            if (instance == null) // 초기 값이 없다면...
            {
                instance = new Theme(); // 초기 값 설정
            }
            return instance; // instance 반환
        }
        public string getThemaColor()
        {
            return themeColor;
        }
        public void setThemaColor(string ThemaColor)
        {
            this.themeColor = ThemaColor;
        }
    }
    public class Button
    {
        private String label;
        
        public Button(String label)
        {
            this.label = label;
        }
        public void display()
        {
            String themeColor = Theme.getInstance().getThemaColor(); // 테마 클래스의 현재 값, 컬러 Get함수 실행
            Console.WriteLine($"Button의 Theme컬러는 {themeColor}입니다...!");
        }
    }
    public class Label
    {
        private String text;
        public Label(String text)
        {
            this.text = text;
        }
        public void display()
        {
            String themeColor = Theme.getInstance().getThemaColor();
            Console.WriteLine($"Label의 Theme컬러는 {themeColor}입니다...!");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button("버튼 라벨");
            Label label = new Label("라벨명");
            // themeColor = light
            button.display();
            label.display();

            Theme.getInstance().setThemaColor("dark"); // theme의 현재 값 set

            // themeColor = dark
            button.display();
            label.display();
        }
    }
}
