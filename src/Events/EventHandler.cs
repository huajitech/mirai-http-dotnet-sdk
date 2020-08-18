using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    public delegate Task EventHandler<TEventArgs>(Session sender, TEventArgs e);
}