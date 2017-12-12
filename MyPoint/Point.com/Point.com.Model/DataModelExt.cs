namespace Point.com.Model
{
    public partial class DataMode
    {
        public string DefaultDbName
        {
            get { return "MLT"; }
        }
    }

    #region  Holyca

    [Repository(DbName = "HolycaDb")]
    public partial class Base_Deliver
    {
    }

    #endregion

    #region BBHome

    [Repository(DbName = "BBHomeDb")]
    public partial class base_t_member
    {
    }

    #endregion
}