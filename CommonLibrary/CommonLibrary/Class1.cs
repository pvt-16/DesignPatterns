public interface ICommand // : derived from Object. So is Program. A derived class of Object
{
    bool Process(string input, ref double data);
}