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

            /* When true, the control’s background color follows the system’s visual style(e.g., Windows theme),
               typically a gradient or themed color, ignoring the BackColor property.
               When false, the control uses the BackColor property explicitly set, overriding the system’s visual style. */
            UseVisualStyleBackColor = true;
        }
    }
}