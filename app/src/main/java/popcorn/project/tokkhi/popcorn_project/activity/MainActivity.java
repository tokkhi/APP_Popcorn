package popcorn.project.tokkhi.popcorn_project.activity;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Layout;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import okhttp3.OkHttpClient;
import okhttp3.ResponseBody;
import okhttp3.logging.HttpLoggingInterceptor;
import popcorn.project.tokkhi.popcorn_project.R;
import popcorn.project.tokkhi.popcorn_project.task.network.Model.Login_input;
import popcorn.project.tokkhi.popcorn_project.task.network.Model.Login_output;
import popcorn.project.tokkhi.popcorn_project.task.network.api.api_Popcorn;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class MainActivity extends AppCompatActivity {


    private String url ="http://192.168.1.19";
    public EditText email;
    public EditText password;
    private Button btOk;
    private TextView tv;
    private LinearLayout layoutForm;
    private LinearLayout layoutResult;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initInstance();

    }

    View.OnClickListener onBtOkClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            callServer();
            showData();
        }
    };

    public void callServer(){
        OkHttpClient client = new OkHttpClient.Builder()
                .addInterceptor(new HttpLoggingInterceptor().setLevel(HttpLoggingInterceptor.Level.BODY))
                .build();
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(url)
                .client(client)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        api_Popcorn service = retrofit.create(api_Popcorn.class);

        Call<Login_output> call= service.login(new Login_input(email.getText().toString(),password.getText().toString()));
        call.enqueue(new Callback<Login_output>() {

         @Override
            public void onResponse(Call<Login_output> call, Response<Login_output> response) {
             if (!(response.body().getError())) {
                 //response.body() have your LoginResult fields and methods  (example you have to access error then try like this response.body().getError() )
                 String msg = response.body().getMessage();
                 String name = response.body().getName();
                 //int docId = response.body().getDoctorid();
                 boolean error = response.body().getError();

                 boolean activie = response.body().getActive();
                 tv.setText("Name:"+name+" Login: " + msg  + " Error :"+ error + activie);
             } else {
                 Toast.makeText(getBaseContext(), response.body().getMessage(), Toast.LENGTH_SHORT).show();


             }

         }





            @Override
            public void onFailure(Call<Login_output> call, Throwable t) {

            }


        });



    }
    private void showData() {
        layoutForm.setVisibility(View.GONE);
        layoutResult.setVisibility(View.VISIBLE);

    }
    private void initInstance() {
        btOk = findViewById(R.id.btOk);
        btOk.setOnClickListener(onBtOkClickListener);
        email = findViewById(R.id.edUsername);
        password = findViewById(R.id.Password);
        tv = findViewById(R.id.tvResult);
        layoutResult = findViewById(R.id.layoutResult);
        layoutForm = findViewById(R.id.layoutForm);

    }
}
