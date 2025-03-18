using System.Runtime.InteropServices;

namespace KeyboardEmulator;

partial class KeyboardEmulator
{
    [LibraryImport("user32.dll", EntryPoint = "SendInput")]
    [return: MarshalAs(UnmanagedType.U4)]
    private static partial uint SendInput(
        uint nInputs,
        [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
        int cbSize);

    public static void SendFastKeys(string text, int afterCharTimeout)
    {
        if (afterCharTimeout == 0)
        {
            SendFastKeys2(text);
            return;
        }
        foreach (var item in text.ToCharArray())
        {
            var input = new INPUT[] {
                ToInput(item, KEYEVENTF.UNICODE),
                ToInput(item, KEYEVENTF.KEYUP) };
            SendInput((uint)input.Length, input, INPUT.Size);
            Thread.Sleep(afterCharTimeout);
        }
    }

    public static void SendFastKeys(string text)
    {
        var chars = text.ToCharArray();
        var inputs = new INPUT[chars.Length];
        for (int i = 0; i < chars.Length; i++)
        {
            inputs[i] = ToInput(chars[i], KEYEVENTF.UNICODE);
            //inputs[i * 2 + 1] = ToInput(chars[i], KEYEVENTF.KEYUP);
        }
        _ = SendInput((uint)inputs.Length, inputs, INPUT.Size);
    }

    public static void SendFastKeys2(string text)
    {
        var chars = text.ToCharArray();
        var inputs = new INPUT[chars.Length * 2];
        for (int i = 0; i < chars.Length; i++)
        {
            inputs[i * 2] = ToInput(chars[i], KEYEVENTF.UNICODE);
            inputs[i * 2 + 1] = ToInput(chars[i], KEYEVENTF.KEYUP);
        }
        _ = SendInput((uint)inputs.Length, inputs, INPUT.Size);
    }

    private static INPUT ToInput(char c, KEYEVENTF flag)
    {
        var input = new INPUT()
        {
            type = InputType.INPUT_KEYBOARD,
        };
        //input.u.ki.wVk = (VirtualKeyShort)c;
        input.u.ki.wScan = (ScanCodeShort)c;
        //input.u.ki.time = (int)DateTime.Now.Ticks;
        input.u.ki.dwFlags = flag;
            //KEYEVENTF.EXTENDEDKEY |
            //KEYEVENTF.UNICODE |
            //KEYEVENTF.KEYUP;//
        //| KEYEVENTF.SCANCODE;
        return input;
    }

    static void Main()
    {
        //Console.WriteLine("Переключитесь в текстовое поле. Ввод начнется через 3 секунды...");
        //Thread.Sleep(3000);
        //SendFastKeysVK("010460700836326521Be/805451266991EE1092W/DtFZr2GK4ckkg]ZtpeXtVG7/wHXjW5g7Dk8yA/7Cw=" +
        //    '\r');

        new MainForm().ShowDialog();
    }
}
