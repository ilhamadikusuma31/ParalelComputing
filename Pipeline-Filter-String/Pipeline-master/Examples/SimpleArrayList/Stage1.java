package Examples.SimpleArrayList;

import Pipeline.StageInterface;

import java.util.ArrayList;
import java.util.Locale;

public class Stage1 implements StageInterface<ArrayList<String>, ArrayList<String>> {

    public ArrayList run(ArrayList payload) {

        //filter ke upper case
        for (int counter = 0; counter < payload.size(); counter++) {
            String pengganti = payload.get(counter).toString().toUpperCase(Locale.ROOT);
            payload.set(counter, pengganti );
        }

        return payload;
    }
}
