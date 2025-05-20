namespace D_WinFormsApp.Controls
{
    public class MyButton : Button
    {
        public MyButton()
        {
            Padding = new Padding(4);
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleRight;
            Size = new Size(86, 37);
            UseVisualStyleBackColor = true;
        }
    }
}