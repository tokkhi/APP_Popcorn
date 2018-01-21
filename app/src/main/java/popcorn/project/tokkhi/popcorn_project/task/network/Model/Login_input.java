package popcorn.project.tokkhi.popcorn_project.task.network.Model;

import android.widget.EditText;

/**
 * Created by Tokkhi on 1/18/2018.
 */

public class Login_input {
    private String Email;
    private String Password;

    public Login_input(String email, String password) {
        this.Email = email;
        this.Password = password;
    }


    /**
     *
     * @return
     * The email
     */
    public String getEmail() {
        return Email;
    }

    /**
     *
     * @param Email
     * The email
     */
    public void setEmail(String Email) {
        this.Email = Email;
    }

    /**
     *
     * @return
     * The password
     */
    public String getPassword() {
        return Password;
    }

    /**
     *
     * @param Password
     * The password
     */
    public void setPassword(String Password) {
        this.Password = Password;
    }

}
