namespace HelloWebAPI.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HelloWorldModel : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'HelloWorldModel' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'HelloWebAPI.Entities.HelloWorldModel' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'HelloWorldModel' 接続文字列を変更してください。
        public HelloWorldModel()
            : base("name=HelloWorldModel")
        {
        }

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        public virtual DbSet<MyWorlds> MyWorlds { get; set; }
    }

    public class MyWorlds
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}