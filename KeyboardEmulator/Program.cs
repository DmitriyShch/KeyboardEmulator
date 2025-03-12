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
            SendFastKeys(text);
            return;
        }
        foreach (var item in text.ToCharArray())
        {
            var input = new INPUT[] { ToInput(item) };
            SendInput(1, input, INPUT.Size);
            Thread.Sleep(afterCharTimeout);
        }
    }

    public static void SendFastKeys(string text)
    {
        var inputs = text.ToCharArray().Select(ToInput).ToArray();
        _ = SendInput((uint)inputs.Length, inputs, INPUT.Size);
    }

    private static INPUT ToInput(char c)
    {
        var input = new INPUT()
        {
            type = InputType.INPUT_KEYBOARD,
        };
        input.u.ki.wScan = (ScanCodeShort)c;
        input.u.ki.dwFlags = KEYEVENTF.UNICODE;
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
