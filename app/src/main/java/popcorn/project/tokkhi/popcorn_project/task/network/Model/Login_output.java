package popcorn.project.tokkhi.popcorn_project.task.network.Model;

/**
 * Created by Tokkhi on 1/18/2018.
 */

public class Login_output {

    private Boolean error;
    private String Name;
    private String message;
    private Integer doctorid;
    private Boolean active;

    /**
     *
     * @return
     * The error
     */
    public Boolean getError() {
        return error;
    }

    /**
     *
     * @param error
     * The error
     */
    public void setError(Boolean error) {
        this.error = error;
    }

    /**
     *
     * @return
     * The message
     */
    public String getName() {
        return Name;
    }

    public String getMessage() {
        return message;
    }

    /**
     *
     * @param message
     * The message
     */
    public void setName(String message) {
        this.Name = message;
    }

    /**
     *
     * @return
     * The doctorid
     */
    public Integer getDoctorid() {
        return doctorid;
    }

    /**
     *
     * @param doctorid
     * The doctorid
     */
    public void setDoctorid(Integer doctorid) {
        this.doctorid = doctorid;
    }

    /**
     *
     * @return
     * The active
     */
    public Boolean getActive() {
        return active;
    }

    /**
     *
     * @param active
     * The active
     */
    public void setActive(Boolean active) {
        this.active = active;
    }

}

