# KTP-GUI

  这是马踏棋盘的图形用户界面程序。

  启动GUI程序后，它会自动在后台启动命令行CLI程序，通过两个共享内存进行通信，一个用于传输指令，一个用于传输数据。当点击“开始计算”按钮时，GUI程序将输入的起始坐标写入指令共享内存，待CLI程序计算完成后，将计算出的路径写入数据共享内存，并且在指令共享内存中返回“Done”。如果遇到错误，则将错误代码写入数据共享内存，在指令共享内存中返回“Error”。