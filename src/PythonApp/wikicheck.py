from rake_nltk import Rake
import wikipedia


def getFromWiki(word):
    try:
        page = wikipedia.page(word)
    except wikipedia.exceptions.DisambiguationError as e:
        return list(e.options)
    except:
        return -1
    stuff=page.summary
    # print(stuff)
    r=Rake()
    r.extract_keywords_from_text(stuff)
    ret=r.get_ranked_phrases()
    return ret
