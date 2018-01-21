package popcorn.project.tokkhi.popcorn_project.task.network.api;

import popcorn.project.tokkhi.popcorn_project.task.network.Model.Login_input;
import popcorn.project.tokkhi.popcorn_project.task.network.Model.Login_output;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Created by Tokkhi on 1/18/2018.
 */

public interface api_Popcorn {

    @POST("Test_api")
    Call<Login_output> login(@Body Login_input body);

}
